import * as React from "react";

export default class Footer extends React.Component<Model.IFooter> {

    render(): JSX.Element {
        return (
            <footer>
                <div className="row">
                    <div className="col-lg-12">
                        <p>Copyright &copy; {this.props.title}</p>
                    </div>
                </div>
            </footer>
        );
    }
}