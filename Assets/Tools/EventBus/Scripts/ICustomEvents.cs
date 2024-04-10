public interface ICustomEvents
{
}

public struct WalkRightButtonPressedEvent : ICustomEvents{}
public struct WalkRightButtonReleasedEvent : ICustomEvents{}
public struct WalkLeftButtonPressedEvent : ICustomEvents { }
public struct WalkLeftButtonReleasedEvent : ICustomEvents { }
public struct JumpButtonPressedEvent : ICustomEvents { }
public struct JumpButtonReleasedEvent : ICustomEvents { }
public struct PauseButtonPressedEvent : ICustomEvents { }
public struct PauseButtonReleasedEvent : ICustomEvents { }
public struct ResumeButtonPressedEvent : ICustomEvents { }
public struct ResumeButtonReleasedEvent : ICustomEvents { }
public struct RestartButtonPressedEvent : ICustomEvents { }
public struct RestartButtonReleasedEvent : ICustomEvents { }



public struct GetDamageEvent : ICustomEvents { }
public struct LifeChangedEvent : ICustomEvents { }
public struct DeadEvent : ICustomEvents { }
