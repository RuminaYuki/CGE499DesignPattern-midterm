using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    public bool IsRecording { get; private set; }
    public bool IsReplaying { get; private set; }

    private float _recordStartTime;
    private readonly List<RecordedCommand> _recorded = new();

    public IReadOnlyList<RecordedCommand> Recorded => _recorded;

    public void StartRecording()
    {
        _recorded.Clear();
        _recordStartTime = Time.time;
        IsRecording = true;
        IsReplaying = false;
    }

    public void StopRecording()
    {
        IsRecording = false;
    }

    public void ExecuteCommand(ICommand command)
    {
        // ระหว่าง replay ไม่ควรบันทึกซ้ำ
        if (IsRecording && !IsReplaying)
        {
            float t = Time.time - _recordStartTime;
            _recorded.Add(new RecordedCommand(t, command));
        }

        command.Execute();
    }

    public void SetReplaying(bool value)
    {
        IsReplaying = value;
        if (value) IsRecording = false;
    }
}