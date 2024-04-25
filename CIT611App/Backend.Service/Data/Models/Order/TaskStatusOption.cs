namespace Backend.Service.Data.Models.Order
{
    public enum TaskStatusOption
    {
        CREATED = 0,
        READY = 1,
        ADDED_TO_TRIP = 2,
        DELIVERED = 3,
        CANCELED = 4,
        EXPIRED = 5,
        DELIVERED_MANUALLY = 6,
        CAN_NOT_DELIVER = 7,
        NEW = 8,
        SCHEDULED = 9,
        ON_MY_WAY = 10,
        ARRIVED_TO_CUSTOMER = 11,
        PICKED_UP = 12,
        UnDefined = 13,
        ARRIVED_TO_STORE = 14,
        ON_MY_WAY_TO_STORE = 15
    }
}
