using System.Collections;
using UnityEngine;

public class ReplaySystem : MonoBehaviour
{
    [SerializeField] private CommandManager commandManager;

    public void Replay()
    {
        if (commandManager.Recorded.Count == 0) return;
        StopAllCoroutines();
        StartCoroutine(ReplayRoutine());
    }

    private IEnumerator ReplayRoutine()
    {
        commandManager.SetReplaying(true);

        float start = Time.time;
        int index = 0;
        var list = commandManager.Recorded;

        while (index < list.Count)
        {
            float elapsed = Time.time - start;
            var item = list[index];

            if (elapsed >= item.time)
            {
                // สำคัญ: ตอน replay "ไม่ record ซ้ำ"
                item.command.Execute();
                index++;
            }
            else
            {
                yield return null;
            }
        }

        commandManager.SetReplaying(false);
    }
}