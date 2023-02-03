namespace Fable.CloudFlare.Workers

open Fable.Core

type IFetchHandler<'environment> =
    abstract fetch: 
        Request 
        * 'environment 
        * ExecutionContext 
        -> JS.Promise<Response>

type IQueueHandler<'environment, 'message> =
    abstract queue: 
        MessageBatch<'message> 
        * 'environment 
        * ExecutionContext 
        -> JS.Promise<unit>

type IScheduledHandler<'environment> =
    abstract scheduled: 
        ScheduledController
        * 'environment 
        * ExecutionContext 
        -> JS.Promise<unit>
