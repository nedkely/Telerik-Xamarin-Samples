﻿using System;
using Android.Content;
using Android.OS;
using Android.Views;
using AndroidX.Core.View;
using Com.Telerik.Widget.Dataform.Engine;
using Com.Telerik.Widget.Dataform.Visualization;
using Com.Telerik.Widget.Dataform.Visualization.Core;

namespace Samples
{
    public class DataFormValidationBehaviorFragment : AndroidX.Fragment.App.Fragment, ExampleFragment
	{
		public String Title() {
			return "Validation Behavior";
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
			ViewGroup rootLayout = (ViewGroup)inflater.Inflate(Resource.Layout.fragment_dataform_grouping, container, false);

			RadDataForm dataForm = (RadDataForm)rootLayout.FindViewById(Resource.Id.data_form_grouping);
			dataForm.LayoutManager = new DataFormLinearLayoutManager(this.Activity);
			Person person = new Person();
			person.Name = "Joe";
			dataForm.SetEntity(person);

			EntityPropertyEditor nameEditor = Android.Runtime.Extensions.JavaCast<EntityPropertyEditor>(dataForm.GetExistingEditorForProperty("Name"));
			nameEditor.Property().Validator = new NonEmptyValidator();
			nameEditor.ValidationViewBehavior = new ValidationAnimationBehavior(this.Activity);

			EntityPropertyEditor mailEditor = Android.Runtime.Extensions.JavaCast<EntityPropertyEditor>(dataForm.GetExistingEditorForProperty("Mail"));
			mailEditor.ValidationViewBehavior = new BlinkValidationBehavior(this.Activity);

			return rootLayout;
		}

		public class BlinkValidationBehavior : DataFormValidationViewBehavior, Java.Lang.IRunnable {
			private View editorView;
			private bool stage1 = true;
			private bool stage2 = true;
			private bool stage3 = true;

			public BlinkValidationBehavior(Context context) : base(context) {
			}

			protected override void ShowNegativeFeedback(ValidationInfo info) {
				base.ShowNegativeFeedback(info);

				this.editorView = this.Editor.RootLayout();

				ViewCompat.Animate(editorView).Alpha(0).SetDuration(50).WithEndAction(this);
			}

			public void Run() {
				if (stage1) {
					ViewCompat.Animate(editorView).Alpha(1).SetDuration(50).WithEndAction(this);
					stage1 = false;
					return;
				}

				if (stage2) {
					ViewCompat.Animate (editorView).Alpha (0).SetDuration (50).WithEndAction (this);
					stage2 = false;
					return;
				}

				if (stage3) {
					ViewCompat.Animate (editorView).Alpha (1).SetDuration (50);
				}

				stage1 = true;
				stage2 = true;
			}
		}
	}
}

