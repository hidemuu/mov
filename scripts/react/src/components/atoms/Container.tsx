import * as React from "react";

type ContainerProps = {
    title: string
    children: React.ReactNode
}

const Container = (props: ContainerProps): JSX.Element => {
    const { title, children } = props

    return (
        <div style={{ background: 'red' }}>
            <span>{title}</span>
            <div>{children}</div>
        </div>
        )
}

export default Container