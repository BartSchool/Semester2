using VPT.Core.Dto_s;

namespace VPT.Core.Interfaces;

public interface IEventCollection
{
    List<DtoEvent> EventList { get; }

    void AddEvent(DtoEvent @event);
    void RemoveEvent(DtoEvent @event);
}
