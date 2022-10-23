import React from 'react';
import { Grid } from '@material-ui/core';
import LineChart from '../atoms/LineChart';
import BarChart from '../atoms/BarChart';
import styles from "../../commons/styles/styles";

export default class ChartSelector extends React.Component {
    render() {
        const { labels, datasets, options, isBar } = this.props;
        return (
            <div>
                <Grid item className={styles.grid} xs={12}>
                    {isBar
                        ? <BarChart
                            labels={labels}
                            datasets={datasets}
                            options={options} />
                        : <LineChart
                            labels={labels}
                            datasets={datasets}
                            options={options} />}
                </Grid>
            </div>
        );
    }
}