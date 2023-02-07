namespace Fable.CloudFlare.Workers

[<AutoOpen>]
module Scheduled =
    type ScheduledController =
        abstract scheduledTime : int
        abstract cron : string
        abstract noRetry : unit -> unit
