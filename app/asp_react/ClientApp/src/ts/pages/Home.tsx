import * as React from "react";

interface IHome {
    children: object,
}

export default class Home extends React.Component<{}, {}> {

    //マウント時イベントハンドラ
    componentDidMount() {

    }


    //API更新ボタンクリックイベント
    handleUpdateButtonClick() {
        fetch('api/home')
            .then((response) => {
                if (response.status === 200) {
                    return response.text();
                } else {
                    throw new Error();
                }
            })
            .then((data) => {
                alert(data);
            })
            .catch((error) => {
                alert("error");
                console.log(error);
            })
    }

    render(): JSX.Element {
        //コンテンツリスト
        const contentsTileData = [
            
        ];

        return (
            <div>
                
            </div>

        );
    }
}