namespace OoBDev.Oobtainium.Recording
{
    internal interface INeedCallRecorder<T>
    {
        public ICallRecorder Recorder { set; }
        public void Capture(T instance);
    }
}
