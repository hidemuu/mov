import {
    useId, 
} from '@fluentui/react-components';

export function useInputId() : string {
    return useId("input");
}