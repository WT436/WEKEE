import { Action } from "@ngrx/store";

export enum MonitorActionTypes {
    GET_MONITOR = '[MONITOR] Get Monitor',
    GET_MONITOR_FAIL = '[MONITOR] Get Monitor Fail'
}

export class GetMonitorAction implements Action {
    readonly type = MonitorActionTypes.GET_MONITOR;
}

export class GetMonitorFailAction implements Action {
    readonly type = MonitorActionTypes.GET_MONITOR_FAIL;
    constructor(public payload: any) {}
}

export type MonitorAction = GetMonitorAction | GetMonitorFailAction;