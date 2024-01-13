﻿namespace OoBDev.Oobtainium.Devices.LanC;

public enum LanCStatusCode : byte
{
    Initial = 0x00,
    IsEjected = 0x01,
    DewCassetteOut = 0x11,
    Ejecting = 0x21,
    Unload = 0x31,
    UnloadEmergency = 0xB1,
    Stop = 0x02,
    Load = 0x12,
    CassetteBusy = 0x22,
    LowBattery = 0x32,
    DewStop = 0x42,
    Emergency = 0x52,
    TapeEnd = 0x62,
    TapeTop = 0x72,
    StopAfterZero = 0x92,
    LoadEmergency = 0xA2,
    StopEmergency1 = 0xB2,
    StopEmergency2 = 0xC2,
    StopNoComment = 0xE2,
    FastForward = 0x03,
    GotoZeroThenPlay = 0x33,
    FastForwardToMemory = 0x43,
    Rewind = 0x83,
    AutoPLay = 0xA3,
    GotoZeroPlayReverse = 0xB3,
    RewindMemoryStop = 0xC3,
    HighSpeedRewind = 0xD3,
    Record = 0x04,
    RecordStandby = 0x14,
    TimerRecord = 0x24,
    TimerRecordSecond = 0x34,
    AudioVideoInsert = 0x44,
    AudioVideoInsertPause = 0x54,
    VideoInsert = 0x64,
    VideoInsertPause = 0x74,
    AudioDub = 0x84,
    AudioDubPause = 0x94,
    CameraRecord = 0xA4,
    CameraStandby = 0xB4,
    EditSearchPlus = 0x85,
    EditSearchMinus = 0x95,
    EditSearchFastForward = 0xA5,
    EditSearchRewind = 0xB5,
    EditPause = 0xF5,
    Play = 0x06,
    X1FastForward = 0x26,
    X1Rewind = 0x36,
    Cue = 0x46,
    Reverse = 0x56,
    X2x3FastForward = 0x66,
    X2x3Rewind = 0x76,
    X9FastForward = 0x86,
    X9Rewind = 0x96,
    FrameSceneCue = 0xA6,
    FrameSceneReverse = 0xB6,
    X14FastForward = 0xC6,
    X14Rewind = 0xD6,
    PlayPauseForward = 0x07,
    FrameForward_ = 0x17,
    FrameForward1_5 = 0x27,
    FrameReverse1_5 = 0x37,
    FrameForward1_10 = 0x47,
    FrameReverse1_10 = 0x57,
    FrameForward = 0x67,
    FrameReverse = 0x77,
    PlayPauseReverse = 0x97,
    AudioLeftInsert = 0x08,
    AudioLeftInsertPause = 0x18,
    AudioRightInsert = 0x28,
    AudioRightInsertPause = 0x38,
    AudioLeftVideoInsert = 0x48,
    AudioLeftVideoInsertPause = 0x58,
    AudioRightVideoInsert = 0x68,
    AudioRightVideoInsertPause = 0x78,

}
/*
* http://www.boehmel.de/lanc.htm#byte0
*/