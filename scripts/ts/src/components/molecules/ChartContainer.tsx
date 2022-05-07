import * as React from "react";
import { Grid } from '@material-ui/core';
import ChartSelector from '../molecules/ChartSelector';
import styles from "../../styles/styles";

export default class ChartContainer extends React.Component<Model.IChartContainer> {

    render(): JSX.Element {
        return (
            <div>
                <Grid container style={{ paddingTop: 30 }} justifyContent="flex-end" direction="row">
                    {this.props.queryLabels.map((label, index) => (
                        <Grid item className={styles().grid} xs={12}>
                            <ChartSelector
                                type={this.props.type}
                                options={this.props.chart.options}
                                labels={this.props.chart.labels}
                                datasets={this.props.chart.datasets.filter(d => { return d.label === label })}
                            />
                        </Grid>
                    ))}
                </Grid>
            </div>
        );
    }
}