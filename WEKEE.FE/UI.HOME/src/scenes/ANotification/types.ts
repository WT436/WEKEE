import { ActionType } from 'typesafe-actions';
import * as actions from './actions';

export interface HomeState {
    readonly loading: boolean;
    readonly completed: boolean;
}

export type HomeActions = ActionType<typeof actions>;