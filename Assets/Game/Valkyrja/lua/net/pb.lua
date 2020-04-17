PBDefine =  [[
syntax = "proto2";

message GameMessage {
  required string action = 1;
  optional bytes  data   = 2;
}

message RequestLoginMessage {
  required string token = 1;
}

message ResponseCommon {
  required int64  code = 1;
  required string msg  = 2;
}

]]