import React, {useState} from 'react';
import { Button, Grid, Typography, Modal, Paper, TextField, Fade } from '@material-ui/core';
import AddCircleIcon from '@material-ui/icons/AddCircle';

export default class NoticeScreen extends React.Component  {
    render() {
        const [open, setOpen] = useState(false);
        const modalWidth = 800;
        const width = 2000;
        const height = 400;
        return (
            <div>
                <Button
                    variant="contained"
                    color="secondary"
                    startIcon={<AddCircleIcon />}
                    onClick={() => setOpen(true)}
                    style={{ marginTop: 30 }}
                >
                    新規作成
        </Button>
                {/* Modal */}
                <Modal open={open} onClose={() => setOpen(false)}>
                    <Fade in={open}>
                        {/* //open={open}は、openがtrueの場合にmodalが開くという意味 */}
                        <Paper style={{ width: modalWidth, position: 'absolute', top: height * 0.1, right: (width - modalWidth - 40) / 2, padding: 20 }}>
                            <Typography style={{ marginLeft: 8 }}>タイトル</Typography>
                            <TextField
                                style={{ margin: 8, paddingBottom: 20 }}
                                margin="normal"
                                fullWidth
                                variant="outlined"
                                className="red-border"
                            />
                            <Typography style={{ marginLeft: 8 }}>コメント</Typography>
                            <TextField
                                style={{ margin: 8, paddingBottom: 20 }}
                                fullWidth
                                margin="normal"
                                multiline
                                rows={4}
                                InputLabelProps={{ shrink: true }}
                                variant="outlined"
                            />
                            <Grid container style={{ paddingTop: 30 }} justify="flex-end" direction="row">
                                <Grid item>
                                    <Button
                                        variant="contained"
                                        color="secondary"
                                        onClick={() => setOpen(true)}
                                        // onClick={addNewCommentRequest}
                                        startIcon={<AddCircleIcon />}
                                    >
                                        投稿
                        </Button>
                                </Grid>
                            </Grid>
                        </Paper>
                    </Fade>
                </Modal>
            </div>
        )
    }
}
export default NoticeScreen