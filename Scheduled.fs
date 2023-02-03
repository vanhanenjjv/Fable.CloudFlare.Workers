namespace Fable.CloudFlare.Workers

open Fable.Core

[<Global>]
type ScheduledController =
    member _.scheduledTime: int = jsNative
    member _.cron: string = jsNative
    member _.noRetry(): unit = jsNative
