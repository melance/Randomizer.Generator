using Randomizer.Generator;
using Randomizer.Generator.Core;
using Randomizer.Generator.Win.Controls;

namespace Randomizer.Generator.Win
{
	public partial class frmMain : Form
	{
		#region Constructor
		public frmMain(String generatorPath)
		{
			InitializeComponent();
			LoadDefinitionList();
			if (!String.IsNullOrEmpty(generatorPath))
			{
				OpenGenerator(generatorPath);
			}
		}
		#endregion

		#region Members
		private List<BaseDefinition> _definitions;
		private Int32 _generatorHoverIndex = -1;
		#endregion

		#region Private Methods
		private void LoadDefinitionList()
		{
			_definitions = Program.DataAccess.GetDefinitionList(d => d.ShowInList).ToList();
			lstGenerators.DataSource = _definitions;
			lstGenerators.DisplayMember = "Name";
			tagList.LoadTags();
		}

		private void FilterDefinitionList()
		{
			lstGenerators.DataSource = (from d in _definitions
										where d.Tags.Intersect(tagList.SelectedTags).Any() &&
											  (d.Name.Contains(txtSearch.Text, StringComparison.CurrentCultureIgnoreCase) || String.IsNullOrWhiteSpace(txtSearch.Text))
										select d).ToList();
		}

		private void OpenGenerator(String generatorPath)
		{
			try
			{
				var generator = BaseDefinition.Deserialize(File.ReadAllText(generatorPath));
				var form = new Forms.frmGenerator()
				{
					Text = generator.Name,
					WindowState = FormWindowState.Maximized,
					MdiParent = this,
					Generator = generator
				};
				var button = new GeneratorWindowButton()
				{
					Text = form.Text,
					Group = "GeneratorWindowButtons",
					Form = form
				};
				form.Show();
				button.Activated += btnGeneratorWindow_Activated;
				button.Closed += btnGeneratorWindow_Closed;
				pnlWindowList.Controls.Add(button);
				button.Active = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Could not load the generator due to the error {ex.Message}.");
			}
		}
		#endregion

		#region Event Handlers
		private void lstGenerators_DoubleClick(Object sender, EventArgs e)
		{
			var name = ((BaseDefinition)lstGenerators.SelectedItem).Name;
			var path = ((DataAccess.FileSystemDataAccess)DataAccess.DataAccess.Instance).GetDefinitionPath(name);
			OpenGenerator(path);
		}

		private void btnGeneratorWindow_Activated(Object sender, EventArgs e)
		{
			var form = ((GeneratorWindowButton)sender).Form;
			form.WindowState = FormWindowState.Maximized;
			form.Activate();
		}

		private void btnGeneratorWindow_Closed(Object sender, FormClosedEventArgs e)
		{
			if (MdiChildren.Length > 0)
			{
				var button = pnlWindowList.Controls.OfType<GeneratorWindowButton>().Where(btn => btn.Form == ActiveMdiChild).FirstOrDefault();
				if (button != null)
					button.Active = true;
			}
		}

		private void refreshGeneratorListToolStripMenuItem_Click(Object sender, EventArgs e)
		{
			LoadDefinitionList();
		}

		private void mnuExit_Click(Object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void mnuSettings_Click(Object sender, EventArgs e)
		{
			var settings = new Forms.frmSettings();
			if (settings.ShowDialog() == DialogResult.OK)
				LoadDefinitionList();
		}

		private void mnuImport_Click(Object sender, EventArgs e)
		{
			if (dlgImport.ShowDialog() == DialogResult.OK)
			{
				File.Copy(dlgImport.FileName, Path.Combine(Program.GeneratorDirectory, Path.GetFileName(dlgImport.FileName)));
				LoadDefinitionList();
			}
		}

		private void mnuConvert_Click(Object sender, EventArgs e)
		{
			var converter = new Forms.frmConvert();
			converter.ShowDialog();
		}

		private void mnuOnlineHelp_Click(Object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("explorer.exe", "http://randomizerhelp.wikidot.com/home:home");
		}

		private void mnuGithub_Click(Object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("explorer.exe", "https://github.com/melance/Randomizer.Generator");
		}

		private void mnuAbout_Click(Object sender, EventArgs e)
		{
			var about = new Forms.frmAbout();
			about.ShowDialog();
		}

		private void btnToggleSelectedTags_Click(Object sender, EventArgs e)
		{
			tagList.ToggleAll();
		}

		private void btnDeselectAllTags_Click(Object sender, EventArgs e)
		{
			tagList.DeselectAll();
		}

		private void btnSelectAllTags_Click(Object sender, EventArgs e)
		{
			tagList.SelectAll();
		}

		private void tagList_TagSelectionChanged(Object sender, EventArgs e)
		{
			FilterDefinitionList();
		}
		#endregion

		private void lstGenerators_MouseMove(Object sender, MouseEventArgs e)
		{
			int index = lstGenerators.IndexFromPoint(e.Location);
			if (index != _generatorHoverIndex)
			{
				if (index >= 0 && index < lstGenerators.Items.Count)
				{
					var description = ((BaseDefinition)lstGenerators.Items[index]).Description;
					toolTips.SetToolTip(lstGenerators, description);
				}
				else
					toolTips.SetToolTip(lstGenerators, String.Empty);
				_generatorHoverIndex = index;
			}
		}

		private void txtSearch_TextChanged(Object sender, EventArgs e)
		{
			FilterDefinitionList();
		}

		private void btnClearSearch_Click(Object sender, EventArgs e)
		{
			txtSearch.Clear();
		}

		private void btnShowTags_Click(Object sender, EventArgs e)
		{
			tagList.Show();
			btnSelectAllTags.Show();
			btnDeselectAllTags.Show();
			btnToggleSelectedTags.Show();
			btnHideTags.Show();
			btnShowTags.Hide();
		}

		private void btnHideTags_Click(Object sender, EventArgs e)
		{
			tagList.Hide();
			btnSelectAllTags.Hide();
			btnDeselectAllTags.Hide();
			btnToggleSelectedTags.Hide();
			btnShowTags.Show();
			btnHideTags.Hide();
		}

		private void btnHideGeneratorList_Click(Object sender, EventArgs e)
		{
			pnlGeneratorList.Hide();
			splGeneratorList.Hide();
			pnlShowGeneratorList.Show();
		}

		private void btnShowGeneratorList_Click(Object sender, EventArgs e)
		{
			pnlGeneratorList.Show();
			splGeneratorList.Show();
			pnlShowGeneratorList.Hide();
		}

		private void lblGeneratorListShow_Paint(Object sender, PaintEventArgs e)
		{
			e.Graphics.TranslateTransform(lblGeneratorListShow.Width / 2, lblGeneratorListShow.Height / 2);
			e.Graphics.RotateTransform(90);
			e.Graphics.DrawString(lblGeneratorListShow.Text, lblGeneratorListShow.Font, Brushes.Black, new Point(0, 0));
			e.Graphics.ResetTransform();
		}
	}
}