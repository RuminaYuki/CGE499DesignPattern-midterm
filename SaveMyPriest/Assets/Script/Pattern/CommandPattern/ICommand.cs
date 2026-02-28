using System;

public interface ICommand
{
    void Execute();
}

[Serializable]
public struct RecordedCommand
{
    public float time;      // เวลา (วินาที) นับจากเริ่มบันทึก
    public ICommand command;

    public RecordedCommand(float time, ICommand command)
    {
        this.time = time;
        this.command = command;
    }
}
