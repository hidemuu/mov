import * as React from "react";
import { useState, useCallback } from "react";

type ButtonProps = {
    onClick: () => void
}

const DecrementButton = (props: ButtonProps) => {
    const { onClick } = props
    console.log('Decrement')
    return <button onClick={ onClick }>Decrement</button>
}

const IncrementButton = React.memo((props: ButtonProps) => {
    const { onClick } = props
    console.log('Increment')
    return <button onClick={onClick}>Increment</button>
})
