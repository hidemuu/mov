import * as React from "react";

const Text = (props: { content: string }) => {
    const { content } = props
    return (
        <p className="text">{content}</p>
    )
}

export default Text