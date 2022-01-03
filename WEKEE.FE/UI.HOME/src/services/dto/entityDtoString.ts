import { SearchOrderPageInput } from './searchOrderPageInput';

export interface EntityDtoString<T = string> extends SearchOrderPageInput {
    agent: T;
}