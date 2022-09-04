import React, { useState } from 'react';
import { Modal, Fade, Paper } from '@material-ui/core';

export default class ModalForm extends React.Component {
    render() {
        const [open, setOpen, content] = useState(false);
        const modalWidth = 800;
        const width = 2000;
        const height = 400;
        return (
            <Modal open={open} onClose={() => setOpen(false)}>
                <Fade in={open}>
                    {/* //open={open}は、openがtrueの場合にmodalが開くという意味 */}
                    <Paper style={{ width: modalWidth, position: 'absolute', top: height * 0.1, right: (width - modalWidth - 40) / 2, padding: 20 }}>
                        {content}
                    </Paper>
                </Fade>
            </Modal>
        )
    }
}