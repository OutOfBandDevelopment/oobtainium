﻿using System.ComponentModel;

namespace OoBDev.Oobtainium.Devices.LanC;

public enum LanCCommand_CameraVtr : byte
{
    Program1 = 0x00,
    Program2 = 0x02,
    Program3 = 0x04,
    Mode = 0x05,
    Program4 = 0x06,
    Program5 = 0x08,
    Program6 = 0x0A,
    Program7 = 0x0C,
    Program8 = 0x0E,
    Program9 = 0x10,
    [Description("May also be Program 10")]
    Program0 = 0x12,
    Program11 = 0x14,
    Program12 = 0x16,
    Program13 = 0x18,
    Program14 = 0x1A,
    Program15 = 0x1C,
    Program16 = 0x1E,
    ProgramNext = 0x20,
    ProgramPrev = 0x22,
    //? = 0x24,
    //? = 0x26,
    X2 = 0x28,
    ModeMovieStill = 0x2A,
    PhotoWrite = 0x2B,
    Eject = 0x2C,
    MainSub = 0x2E,
    Stop = 0x30,
    Pause = 0x32,
    StartStopToggle = 0x33,
    Play = 0x34,
    Tele = 0x35,
    Rewind = 0x36,
    Wide = 0x37,
    FastForward = 0x38,
    PhotoCapture = 0x39,
    Record = 0x3A,
    RecordPause = 0x3C,
    // ? = 0x3E
    Still = 0x40,
    // ? = 0x42,
    X1_10 = 0x44,
    X1_5 = 0x46,
    // ? = 0x48,
    X14 = 0x4A,
    X9 = 0X4C,
    TrackingAutoManualToggle = 0x4E,
    SearchPlus = 0x50,
    SearchMinus = 0x52,
    TvVtrToggle = 0x54,
    // ? = 0x56,
    // ? = 0x58
    Vtr = 0x5A,
    SearchTypeToggle = 0x5B,
    // ? = 0x5C 
    PowerOff = 0x5E,
    RewindFrame = 0x60,
    ForwardFrame = 0x62,
    // ? = 0x64,
    EditSearchPlus = 0x65,
    X1 = 0x66,
    EditSearchMinus = 0x67,
    // ? = 0x68,
    RecordReview = 0x69,
    // ? = 0x6A,
    Sleep = 0x6C,
    TrackingNormal = 0x6E,
    // ? = 0x70
    // ? = 0x72
    RewindPlay = 0x74,
    // ? = 0x76
    Aux = 0x78,
    SlowPlus = 0x7A,
    TapeEndSearch = 0x7B,
    SlowMinux = 0x7C,
    // ? = 0x7E,
    // ? = 0x80,
    DisplayMode = 0x82,
    MenuUp = 0x84,
    MenuDown = 0x86,
    TrackingFinePlus = 0x88,
    TrackingFineMinus = 0x8A,
    CounterReset = 0x8C,
    ZeroMemory = 0x8E,
    IndexMark = 0x90,
    IndexErase = 0x92,
    ShuttleEditPlus = 0x94,
    ShuttleEditMinu = 0x96,
    DataCode_Goto = 0x98,
    DataCode_RecordingParameter = 0x99,
    Menu = 0x9A,
    // ? = 0x9C,
    InputSelect = 0x9E,
    // ? = 0xA0,
    Execute = 0xA2,
    QuickTimer = 0xA4,
    Index = 0xA6,
    // ? = 0xA8,
    // ? = 0xAA,
    IndexSearchPlus = 0xAC,
    IndexSearchMinus = 0xAE,
    TapeSpeed = 0xB0,
    GotoZero_TapeReturn = 0xB2,
    CounterDisplay = 0xB4,
    OpenCloseToggle = 0xB6,
    TimerDIsplay = 0xB8,
    // ? = 0xBA,
    // ? = 0xBC,
    DateDisplayOff = 0xBD,
    // ? = 0xBE,
    DateDisplayOn = 0xBF,
    TimerSet = 0xC0,
    MenuRight = 0xC2,
    MenuLeft = 0xC4,
    TimerClear = 0xC6,
    TimerCheck = 0xC8,
    TimerRecord = 0xCA,
    // ? = 0xCC,
    // ? = 0xCE,
    AudioDub = 0xD0,
    // ? = 0xD2,
    EditAssemble = 0xD4,
    EditMark = 0xD6,
    SynchroEdit = 0xD8,
    // ? = 0xDA,
    DigitalOff_Print = 0xDC,
    SpeedPlus = 0xDE,
    SpeedMinus = 0xE0,
    StopMotion = 0xE2,
    // ? = 0xE4,
    // ? = 0xE6,
    ChannelScan = 0xE8,
    // ? = 0xEA,
    VoiceBoost = 0xEC,
    // ? = 0xEE,
    // ? = 0xF0,
    // ? = 0xF2,
    // ? = 0xF4,
    // ? = 0xF6,
    DigitalScan = 0xF8,
    HighSpeedReview = 0xFA,
    Still_Shuttle = 0xFC,
    // ? = 0xFE,

}
/*
* http://www.boehmel.de/lanc.htm#byte0
*/
