import { action } from 'typesafe-actions';
import { PagedListOutput } from '../../../services/dto/pagedListOutput';
import { SearchOrderPageInput } from '../../../services/dto/searchOrderPageInput';

import ActionTypes from './constants';
import { ResourceReadDto } from './dto/resourceReadDto';

//#region GET_RESOURCE
export const getResourceStart = (input: SearchOrderPageInput) =>
action(ActionTypes.GET_RESOURCE_START, input);
export const getResourceCompleted = (output: PagedListOutput<ResourceReadDto>) =>
action(ActionTypes.GET_RESOURCE_COMPLETED, output);
export const getResourceError = () =>
action(ActionTypes.GET_RESOURCE_ERROR);
//#endregion