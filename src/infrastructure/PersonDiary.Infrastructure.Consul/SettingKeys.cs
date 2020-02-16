namespace PersonDiary.Infrastructure.Consul
{
    public struct SettingKeys
    {
        public const string LifeEventsServiceUrl = "LifeEventsServiceUrl";
        public const string PersonsServiceUrl = "PersonsServiceUrl";
        public const string RedisSettingsKey = "PersonDiarySettings";
        public const string ConnectionString = "ConnectionString";
        public const string ConnectionStringLifeEvent = "ConnectionStringLifeEvent";
        public const string ConnectionStringPerson = "ConnectionStringPerson";
        public const string EventBusConnectionStringPerson = "EventBusConnectionStringPerson";
    }
}