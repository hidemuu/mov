import * as React from "react";
import { useState } from "react";

type SimpleCounterProps = {
    initialValue: number
}

const SimpleCounter = (props: SimpleCounterProps) => {
    const { initialValue } = props
    const [count, setCount] = useState(initialValue)

    return (
        <div>
            <p>Count: {count}</p>
            <button onClick={() => setCount(count - 1)}>-</button>
            <button onClick={() => setCount((prevCount) => prevCount + 1)}>+</button>
        </div>
        )
}

export default SimpleCounter