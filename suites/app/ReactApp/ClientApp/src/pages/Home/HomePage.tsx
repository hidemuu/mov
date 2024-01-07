import * as React from 'react'
import { PageHeader } from '../../components/organisms/PageHeader'

export const HomePage: React.FunctionComponent = () => {
  return (
    <>
      <PageHeader
        title={'Home'}
        description={'Welcome to Mov Suite!'}
      ></PageHeader>
    </>
  )
}
