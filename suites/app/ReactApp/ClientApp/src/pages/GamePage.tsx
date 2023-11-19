import React from 'react';
import styled from 'styled-components';

const Container = styled.div`
  margin: 24px auto 0;
  width: 100%;
  max-width: 376px;
`;

const Score = styled.div`
  position: relative;
  font-family: monospace;
  font-size: 18px;
  color: #888;
`;

const LeftHalf = styled.div`
  display: inline-block;
  width: 50%;
`;

const RightHalf = styled(LeftHalf)`
  text-align: right;
`;

const Column = styled.div`
  display: inline-block;
  vertical-align: top;
`;

const LeftColumn = styled(Column)`
  width: 88px;
`;

const RightColumn = styled(LeftColumn)`
  padding-left: 15px;
`;

const MiddleColumn = styled(Column)`
  width: 200px;
`;

const Popup = styled.div`
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  background: #fff;
  padding: 12px 24px;
  border-radius: 4px;
  text-align: center;
  box-shadow: 2px 7px 18px 3px #d2d2d2;
`;

const Alert = styled.h2`
  color: #666;
  margin: 0;
`;

const Button = styled.button`
  border: 1px solid #666;
  background: none;
  margin-top: 12px;
  border-radius: 4px;
`;

export const GamePage: React.FunctionComponent = () => {
    return (
        <Container>
    
        </Container>
    );
};