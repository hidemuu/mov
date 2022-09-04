import * as React from "react";

export default class Header extends React.Component<Model.IHeader> {

    render(): JSX.Element {
        return (
            <header>
                <div className="row">
                    <div className="col-lg-12">
                        <h1>{this.props.title}</h1>
                    </div>
                </div>
            </header>
        );
    }
}