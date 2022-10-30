import * as React from "react";
// import Image, { ImageProps } from 'next/image'
import styled from 'styled-components'

type ImageShape = 'circle' | 'square'
// type ShapeImageProps = ImageProps & { shape?: ImageShape }

// const ImageWithShape = styled(Image)<{ shape?: ImageShape }>`
//   border-radius: ${({ shape }) => (shape === 'circle' ? '50%' : '0')};
// `

/**
 * シェイプイメージ
 */
// const ShapeImage = (props: ShapeImageProps) => {
//   const { shape, ...imageProps } = props

//   return <ImageWithShape shape={shape} {...imageProps} />
// }

const ShapeImage = (props: any) => {
  const { shape, ...imageProps } = props

  return <div />
}

export default ShapeImage
