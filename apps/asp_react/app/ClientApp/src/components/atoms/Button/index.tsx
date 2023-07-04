import * as React from "react";
import styled, { css } from "styled-components"

const variants = {
    primary: {
        color: '#ffffff',
        backgroundColor: '#1D3461',
        border: 'none',
    },
    success: {
        color: '#ffffff',
        backgroundColor: '#5AB203',
        border: 'none',
    },
    transparent: {
        color: '#111111',
        backgroundColor: 'transparent',
        border: '1px solid black',
    },
} as const

type ButtonProps = {
    label: string
    text: string
    disabled: boolean
    onClick: React.MouseEventHandler<HTMLButtonElement>
}

const Button = (props: ButtonProps) =>
{
    const { label, text, disabled, onClick } = props

    return (
        <div className="button-container">
            <span>{label}</span>
            <button disabled={disabled} onClick={onClick}>{text}</button>
        </div>
    )
}

export default Button