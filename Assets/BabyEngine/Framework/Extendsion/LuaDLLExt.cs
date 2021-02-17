namespace XLua.LuaDLL {
    using XLua.LuaDLL;
    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    using XLua;

    public partial class Lua {
        #region luaopen_pb
        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaopen_pb(System.IntPtr L);

        [MonoPInvokeCallback(typeof(LuaDLL.lua_CSFunction))]
        public static int LoadPB(System.IntPtr L) {
            return luaopen_pb(L);
        }
        #endregion

        #region luaopen_rapidjson
        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaopen_rapidjson(System.IntPtr L);
        [MonoPInvokeCallback(typeof(LuaDLL.lua_CSFunction))]
        public static int LoadRapidJson(System.IntPtr L) {
            return luaopen_rapidjson(L);
        }
        #endregion

        #region luaopen_lpeg
        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaopen_lpeg(System.IntPtr L);
        [MonoPInvokeCallback(typeof(LuaDLL.lua_CSFunction))]
        public static int LoadLPeg(System.IntPtr L) {
            return luaopen_lpeg(L);
        }
        #endregion

        #region luaopen_ffi
        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaopen_ffi(System.IntPtr L);
        [MonoPInvokeCallback(typeof(LuaDLL.lua_CSFunction))]
        public static int LoadFFI(System.IntPtr L) {
            return luaopen_ffi(L);
        }
        #endregion

        #region luaopen_serialize
        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaopen_serialize(System.IntPtr L);
        [MonoPInvokeCallback(typeof(LuaDLL.lua_CSFunction))]
        public static int LoadSerialize(System.IntPtr L) {
            return luaopen_serialize(L);
        }
        #endregion

        #region luaopen_cmsgpack
        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaopen_cmsgpack(System.IntPtr L);
        [MonoPInvokeCallback(typeof(LuaDLL.lua_CSFunction))]
        public static int LoadCMSGPack(System.IntPtr L) {
            return luaopen_cmsgpack(L);
        }
        #endregion
    }
}