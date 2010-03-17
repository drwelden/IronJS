﻿using System.Collections.Generic;
using Antlr.Runtime.Tree;
using IronJS.Ast.Tools;
using IronJS.Runtime.Js;
using Microsoft.Scripting.Utils;
using IronJS.Runtime.Binders;
using System.Dynamic;
using IronJS.Tools;

#if CLR2
using Microsoft.Scripting.Ast;
#else
using System.Linq.Expressions;
#endif

namespace IronJS.Ast.Nodes {
	using Et = Expression;

	public class Invoke : Base {
		public INode Target { get { return Children[0]; } }

		public Invoke(INode target, List<INode> args, ITree node)
			: base(NodeType.Call, node) {
			Children = ArrayUtils.Insert(target, args.ToArray());
		}

		public override INode Analyze(Stack<Lambda> stack) {
			base.Analyze(stack);
			AnalyzeTools.IfIdentiferUsedAs(Target, Types.Object);
			return this;
		}

		public override Et Compile(Lambda func) {
			return Et.Dynamic(
				new IronJS.Runtime.Binders.CallBinder(new CallInfo(Children.Length - 1)),
				typeof(object),
				ArrayUtils.InsertAt(
					ArrayTools.Map(Children, delegate(INode node) {
						return node.Compile(func);
					}),
					1, /* position */
					CompileTools.Globals(func)
				)
			);
		}
	}
}