using NSubstitute;
using NUnit.Framework;
using System;

public class GameManagerTests
{
    private IEventBus _eventBus;
    private ICharacterFactory _characterFactory;

    [SetUp]
    public void SetUp()
    {
        _eventBus = Substitute.For<IEventBus>();
        _characterFactory = Substitute.For<ICharacterFactory>();
    }

    [Test]
    public void SubscribeToPauseButtomPressedEventOnCreated()
    {
        WhenCreateGameManager();

        ThenItSubscribesToEvent<PauseButtonPressedEvent>();
    }

    private void WhenCreateGameManager()
    {
        new GameManager(_eventBus, _characterFactory);
    }

    private void ThenItSubscribesToEvent<T>() where T : ICustomEvents
    {
        _eventBus.Received(1).Subscribe<T>(Arg.Any<Action>());
    }
}
