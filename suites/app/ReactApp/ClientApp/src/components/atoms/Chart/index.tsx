import Highcharts from 'highcharts'
import HighchartsReact from 'highcharts-react-official'
import React, { FC } from 'react'

const Styles: { [key: string]: React.CSSProperties } = {
  graph: {
    padding: '12px'
  }
}

declare type ChartProps = {
  chartOptions: Highcharts.Options
}

export const Chart: FC<ChartProps> = ({ chartOptions }) => {
  return (
    <div style={Styles.graph}>
      <HighchartsReact highcharts={Highcharts} options={chartOptions} />
    </div>
  )
}
