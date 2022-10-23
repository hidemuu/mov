import React from 'react';
import { Grid } from '@material-ui/core';
import ChartSelector from '../molecules/ChartSelector';
import styles from "../../commons/styles/styles";

export default class ChartContainer extends React.Component {
    render() {
        const { labels, datasets, options, queryLabels, isBar } = this.props;
        return (
            <div>
                <Grid container style={{ paddingTop: 30 }} justifyContent="flex-end" direction="row">
                    {queryLabels.map((label, index) => (
                        <Grid item className={styles.grid} xs={12}>
                            <ChartSelector
                                labels={labels}
                                datasets={datasets.filter(d => { return d.label === label })}
                                options={options}
                                isBar={isBar} />
                        </Grid>
                    ))}
                </Grid>
            </div>
        );
    }
}