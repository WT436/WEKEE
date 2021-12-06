import { action } from 'typesafe-actions';
import { OrderByListInput } from '../../services/dto/orderByListInput';
import { PagedListOutput } from '../../services/dto/pagedListOutput';

import ActionTypes from './constants';
import { ExceptionDtos } from './dtos/exceptionDtos';
// open page login
export const getListErrorSystemStart = (input: OrderByListInput) =>
    action(ActionTypes.GET_LIST_ERROR_SYSTEM_START, input);
export const getListErrorSystemCompleted = (input: PagedListOutput<ExceptionDtos>) =>
    action(ActionTypes.GET_LIST_ERROR_SYSTEM_COMPLETED, input);
export const getListErrorSystemError = () =>
    action(ActionTypes.GET_LIST_ERROR_SYSTEM_ERROR);

export const fixErrorSystemStart = (input: Number) =>
    action(ActionTypes.FIX_ERROR_SYSTEM_START, input);
export const fixErrorSystemCompleted = (input: Number) =>
    action(ActionTypes.FIX_ERROR_SYSTEM_COMPLETED, input);
export const fixErrorSystemError = () =>
    action(ActionTypes.FIX_ERROR_SYSTEM_ERROR);