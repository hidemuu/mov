import React, { useState, useRef } from 'react'

const sleep = (ms: number) => new Promise((resolve) => setTimeout(resolve, ms))

const UPLOAD_DELAY = 5000

const ImageUploader = () => {
    const inputImageRef = useRef<HTMLInputElement | null>(null)
    const fileRef = useRef<File | null>(null)
    const [message, setMessage] = useState<string | null>('')

    const onClickText = () => {
        if(inputImageRef.current !== null){
            inputImageRef.current.click()
        }
    }

    const onChangeImage = (e: React.ChangeEvent<HTMLInputElement>) => {
        const files = e.target.files
        if(files !== null && files.length > 0){
            fileRef.current = files[0]
        }
    }

    const onClickUpload = async() => {
        if(fileRef.current !== null){
            // APIを呼ぶ関数を入れる。ひとまず疑似的にSleep入れている
            await sleep(UPLOAD_DELAY)
            setMessage(`${fileRef.current.name} has been successfully uploaded`)
        }
    }

    return (
        <div>
            <p style={{ textDecoration: 'underline' }} onClick={onClickText}>
                画像をアップロード
            </p>
            <input
                ref={inputImageRef}
                type='file'
                accept='image/*'
                onChange={onChangeImage}
                style={{ visibility: 'hidden' }}>
            </input>
            <br />
            <button onClick={onClickUpload}>アップロードする</button>
            {message !== null && <p>{message}</p>}
        </div>
    )
}

export default ImageUploader