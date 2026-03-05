using UnityEngine;
public abstract class GameEvent { }
public sealed class BossDefeatedEvent : GameEvent{}
public sealed class PlayerDieEvent : GameEvent{}

public sealed class ReplayingEvent : GameEvent{}

