﻿using Mov.Designer.Models.Persistences;
using Mov.Layouts;
using Mov.Layouts.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public interface IDesignerService
    {
        #region プロパティ

        #endregion プロパティ

        #region メソッド

        void SetEngine(int domainId);

        #region UIモデル

        LayoutNode GetNodeModel(ShellRegion region);

        #endregion UIモデル

        #region クエリ

        void Read();

        IEnumerable<Node> GetNodes();

        Node GetNode(Guid id);

        IEnumerable<Content> GetContents();

        Content GetContent(Guid id);

        Content GetContent(string code);

        IEnumerable<Shell> GetShells();

        Shell GetShell(ShellRegion region);

        #endregion クエリ

        #region コマンド

        void Write();

        void PostNodes(IEnumerable<Node> items);

        void DeleteNode(Node item);

        void PostContents(IEnumerable<Content> items);

        void DeleteContent(Content item);

        void PostShells(IEnumerable<Shell> items);

        void PostShell(Shell item);

        void DeleteShell(Shell item);


        #endregion コマンド

        #endregion メソッド

    }
}