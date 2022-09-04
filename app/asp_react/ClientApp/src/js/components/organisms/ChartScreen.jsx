import React from 'react';
import ChartSelector from '../molecules/ChartSelector';
import ChartContainer from '../molecules/ChartContainer';
import TypographyLabel from '../atoms/TypographyLabel';

export default class ChartScreen extends React.Component {
    render() {
        const { chartLabels, chartData, options, queryLabels, isAll } = this.props;
        return (
            <div>
                {isAll ?
                    <div>
                    <TypographyLabel content = "一覧" />
                    <ChartSelector
                        labels={chartLabels}
                        datasets={chartData}
                        options={options}
                        isBar={false} />
                </div > :
                <div>
                    <TypographyLabel content="個別" />
                    <ChartContainer
                        labels={chartLabels}
                        datasets={chartData}
                        options={options}
                        queryLabels={queryLabels}
                        isBar={true} />
                 </div>}
            </div>
            );
    }
}