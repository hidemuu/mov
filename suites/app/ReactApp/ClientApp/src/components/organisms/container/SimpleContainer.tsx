import React from 'react'

type SimpleContainerProps = {
    title: string
    children: React.ReactNode
}

export const SimpleContainer = (props: SimpleContainerProps): JSX.Element => {
    const { title, children } = props

    return (
        <div style={{ background: 'red' }}>
            <span>{title}</span>
            <div>{children}</div>
        </div>
    )
}