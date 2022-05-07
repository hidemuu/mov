import * as React from "react";
import ChartSelector from '../molecules/ChartSelector';
import ChartContainer from '../molecules/ChartContainer';
import TypographyLabel from '../atoms/TypographyLabel';


export default class ChartScreen extends React.Component<Model.IChartScreen, Field.IChartScreen> {

    render(): JSX.Element {

        this.state.isAllType.isBar = false;
        this.state.type.isBar = true;

        return (
            <div>
                {this.props.isAll ?
                    <div>
                        <TypographyLabel content="一覧" />
                        <ChartSelector
                            chart={this.props.chart}
                            type={this.state.isAllType} />
                    </div > :
                    <div>
                        <TypographyLabel content="個別" />
                        <ChartContainer
                            chart={this.props.chart}
                            queryLabels={this.props.queryLabels}
                            type={this.state.type} />
                    </div>}
            </div>
        );
    }
}