import * as React from "react";
import { Grid } from '@material-ui/core';
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import { Tab, Tabs, TabList, TabPanel } from 'react-tabs';
import 'react-tabs/style/react-tabs.css';
import styles from "../../styles/styles";


export default class DateTab extends React.Component<Model.IDateTab> {

    render(): JSX.Element {
        return (
            <div className={styles().board}>
                <Grid container style={{ paddingTop: 10, paddingBottom: 10 }} justifyContent="flex-end" direction="row">
                    <Grid item className={styles().grid} xs={9}>
                        <Tabs onSelect={(index, last) => this.props.onSelectTab(index, last)} selectedIndex={this.props.selectedTabIndex}>
                            <TabList>
                                <Tab>週</Tab>
                                <Tab>月</Tab>
                                <Tab>年</Tab>
                            </TabList>
                            <TabPanel>
                                <h2>週報</h2>
                            </TabPanel>
                            <TabPanel>
                                <h2>月報</h2>
                            </TabPanel>
                            <TabPanel>
                                <h2>年報</h2>
                            </TabPanel>
                        </Tabs>
                    </Grid>
                    <Grid item className={styles().grid} xs={3}>
                        <DatePicker selected={this.props.selectedDate} onChange={(date) => this.props.onChangeDatepicker(date)} />
                    </Grid>
                </Grid>
            </div>
        );
    }
}