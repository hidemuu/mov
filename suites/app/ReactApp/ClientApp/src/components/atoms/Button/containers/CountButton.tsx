import { useState, useCallback } from 'react'
import { Button } from '../index'

const usePouup = () => {
    const cb = useCallback((text: string) => {
        prompt(text)
    }, [])
    return cb
}

type CountButtonProps = {
    maximum: number
}

export const CountButton = (props: CountButtonProps) => {
    const { maximum } = props
    const displayPopup = usePouup()
    const [count, setCount] = useState(0)
    const onClick = useCallback(() => {
        const newCount = count + 1
        setCount(newCount)
        if(newCount >= maximum){
            displayPopup(`You've clicked ${newCount} times`)
        }
    }, [count, maximum])
    
    const disabled = count >= maximum
    const text = disabled ? 'Can\'t click any more' : `You've clicked ${count} times`

    return (
        <Button onClick={onClick} label={text} />
    )
}