namespace Fable.CloudFlare.Workers

type ScheduledController =
    abstract scheduledTime : int
    abstract cron : string
    abstract noRetry : unit -> unit
