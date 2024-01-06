import { makeStyles, shorthands } from '@fluentui/react-components'

export const useStyles = makeStyles({
  root: {
    alignItems: 'flex-start',
    display: 'flex',
    flexDirection: 'column',
    justifyContent: 'flex-start',
    ...shorthands.padding('50px', '20px'),
    rowGap: '20px'
  },
  panels: {
    ...shorthands.padding(0, '10px'),
    '& th': {
      textAlign: 'left',
      ...shorthands.padding(0, '30px', 0, 0)
    }
  },
  grid: {
    ...shorthands.gap('16px'),
    display: 'flex',
    flexDirection: 'column'
  },
  combobox: {
    // Stack the label above the field with a gap
    display: 'grid',
    gridTemplateRows: 'repeat(1fr)',
    justifyItems: 'start',
    ...shorthands.gap('2px'),
    maxWidth: '400px'
  }
})
