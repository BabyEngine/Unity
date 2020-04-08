using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BabyEngine {

    public class Tween {
        internal Vector3 target= Vector3.zero;
        internal float duration = 0;
        internal bool isPause = false;
        internal Coroutine co = null;
        internal bool isAutoKill = true;
        internal Transform transform ;
        public delegate void OnComplete();
        internal OnComplete onComplete = null;
        public Tween(Transform transform, float duration) {
            this.duration = duration;
            this.transform = transform;
            TweenManager.GetInstance().Add(this);
        }
        public void SetCoroutine(Coroutine co) {
            this.co = co;
        }
        public void SetAutoKill(bool isAutoKill) {
            this.isAutoKill = isAutoKill;
        }

       public void Kill() {
            if (co == null) {
                return;
            }
            MonoBehaviour mono = transform.GetComponent<MonoBehaviour>();
            mono.StopCoroutine(co);
            TweenManager.GetInstance().Remove(this);
            co = null;
        }

        internal void runOnComplete() {
            if (onComplete != null) {
                onComplete?.Invoke();
            }
            if (isAutoKill) {
                Kill();
            }
        }

        public void Pause() {
            isPause = true;
        }

        internal void Play() {
            isPause = false;
        }
    }

    public class TweenManager {
        private static TweenManager mgr = null;
        public static TweenManager GetInstance() {
            if (mgr == null) {
                mgr = new TweenManager();
            }
            return mgr;
        }

        private static List<Tween> tweens = new List<Tween>();

        public void Add(Tween t) {
            tweens.Add(t);
        }
        
        public void Remove(Tween t) {
            tweens.Remove(t);
        }

        public void Kill(Transform transform) {
            for (int i = tweens.Count; i >= 0; i--) {
                var t = tweens[i];
                if (t.transform == transform) {
                    t.Kill();
                }
            }
        }
        public void KillAll() {
            for (int i = tweens.Count; i >= 0; i--) {
                tweens[i].Kill();
            }
        }

        public void Pause(Transform transform) {
            for (int i = tweens.Count; i >= 0; i--) {
                var t = tweens[i];
                if (t.transform == transform) {
                    t.Pause();
                }
            }
        }

        public void PauseAll() {
            for (int i = tweens.Count; i >= 0; i--) {
                tweens[i].Pause();
            }
        }

        public void Play(Transform transform) {
            for (int i = tweens.Count; i >= 0; i--) {
                var t = tweens[i];
                if (t.transform == transform) {
                    t.Play();
                }
            }
        } 
        public void PlayAll(Transform transform) {
            for (int i = tweens.Count; i >= 0; i--) {
                tweens[i].Play();
            }
        }
    }
    
    public static class TweenExtension {
        #region DoMove
        public static IEnumerator DoMove(this MonoBehaviour mono, Tween tween) {
            Vector3 speed = (tween.target - tween.transform.position) / tween.duration;
            for (float f = tween.duration; f >= .0f; f -= Time.deltaTime) {
                tween.transform.Translate(speed * Time.deltaTime);
                yield return null;
                while (tween.isPause) {
                    yield return null;
                }

            }
            tween.runOnComplete();
        }

        public static Tween DoMove(this Transform transform, Vector3 target, float duration) {
            MonoBehaviour mono = transform.GetComponent<MonoBehaviour>();
            Tween tween = new Tween(transform, duration);
            tween.target = target;
            Coroutine co = mono.StartCoroutine(mono.DoMove(tween));
            tween.SetCoroutine(co);
            return tween;
        }
        #endregion

        #region DoScale
        public static IEnumerator DoScale(this MonoBehaviour mono, Tween tween) {
            Vector3 speed = (tween.target - tween.transform.localScale) / tween.duration;
            for (float f = tween.duration; f >= .0f; f -= Time.deltaTime) {
                tween.transform.localScale += speed * Time.deltaTime;
                yield return null;
                while (tween.isPause) {
                    yield return null;
                }

            }
            tween.runOnComplete();
        }

        public static Tween DoScale(this Transform transform, Vector3 target, float duration) {
            MonoBehaviour mono = transform.GetComponent<MonoBehaviour>();
            Tween tween = new Tween(transform, duration);
            tween.target = target;
            Coroutine co = mono.StartCoroutine(mono.DoScale(tween));
            tween.SetCoroutine(co);
            return tween;
        }
        #endregion
    }
}
