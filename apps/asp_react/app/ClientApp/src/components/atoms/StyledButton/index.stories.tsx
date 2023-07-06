import { ComponentMeta } from '@storybook/react'
import { StyledButton } from './index'

export default {
    title: 'StyledButton',
    component: StyledButton,
} as ComponentMeta<typeof StyledButton>

export const Primary = (props: any) => {
    return (
        <StyledButton {...props} variant="primary">
            Primary
        </StyledButton>
    )
}

export const Success = (props: any) => {
    return (
        <StyledButton {...props} variant="primary">
            Success
        </StyledButton>
    )
}

export const Transparent = (props: any) => {
    return (
        <StyledButton {...props} variant="transparent">
            Transparent
        </StyledButton>
    )
}