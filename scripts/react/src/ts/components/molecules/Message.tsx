import * as React from "react";
import Text from '../atoms/Text'

const Message = (props: {}) => {
    const content1 = ''
    const content2 = ''

    return (
        <div>
            <Text content={content1} />
            <Text content={content2} />
        </div>
        )
}

export default Message