using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Randomizer.Generator.Core;
using SadConsole;
using SadConsole.UI.Controls;
using SadConsole.UI.Themes;
using SadRogue.Primitives;

namespace Randomizer.Generator.MonoGame.Dialogs
{
    partial class GeneratorConsole
    {
        private const String CLOSE_TEXT = "X";
        private const String PARAMETERS_TEXT = "Parameters";
        private const String GENERATE_TEXT = "Generate";
        private const String CLEAR_TEXT = "Clear";
        private const String SAVE_TEXT = "Save";
        private const String COPY_TEXT = "Copy";
        private const String REPEAT_TEXT = "Repeat";

        public GeneratorConsole(BaseDefinition generator,Int32 x, Int32 y, Int32 width, Int32 height) : base(width, height)
        {
            Position = new Point(x, y);
            TitleBar = new Rectangle(0, 0, width, 3);
            ParameterArea = new Rectangle(0, 1, width / 3, height - 4);
            ParameterButtonArea = new Rectangle(0, ParameterArea.Height + ParameterArea.Y , width / 3, 3);
            ResultArea = new Rectangle(ParameterArea.X + ParameterArea.Width + 1, ParameterArea.Y, width - ParameterArea.Width - 3, height - 4);
            ResultButtonArea = new Rectangle(ResultArea.X, ResultArea.Y + ResultArea.Height, ResultArea.Width, 3);
            ResultClientArea = new Rectangle(ResultArea.X + 1, ResultArea.Y + 1, ResultArea.Width - 2, ResultArea.Height - 4);

            _generator = generator;

            this.DrawBox(ParameterArea, Styles.BorderColor, null, ICellSurface.ConnectedLineThin);
            this.DrawBox(ParameterButtonArea, Styles.BorderColor, null, ICellSurface.ConnectedLineThin);
            this.DrawBox(ResultArea, Styles.BorderColor, null, ICellSurface.ConnectedLineThin);
            this.DrawBox(ResultButtonArea, Styles.BorderColor, null, ICellSurface.ConnectedLineThin);

            btnClose = new(CLOSE_TEXT.Length + 2)
            {
                Position = new Point(TitleBar.Width - TitleBar.X - (CLOSE_TEXT.Length + 3), TitleBar.Y),
                Text = CLOSE_TEXT
            };
            lblName = new(generator.Name)
            {
                Position = new Point(TitleBar.X + 1, TitleBar.Y),
                TextColor = Styles.TitleColor
            };
            pnlParameters = new(ParameterArea.Width - 2, ParameterArea.Height - 2)
            {
                Position = new Point(ParameterArea.X + 1, ParameterArea.Y + 1)
            };
            lblParameters = new(PARAMETERS_TEXT)
            {
                Position = new Point(ParameterArea.X + 2, ParameterArea.Y + 1),
                TextColor = Styles.TitleColor
            };
            btnGenerate = new Button(GENERATE_TEXT.Length + 2)
            {
                Position = new Point(ParameterButtonArea.Width - (GENERATE_TEXT.Length + 3), ParameterButtonArea.Y + 1),
                Text = GENERATE_TEXT
            };
            btnSave = new Button(SAVE_TEXT.Length + 2)
            {
                Position = new Point(ResultButtonArea.X + ResultButtonArea.Width - (SAVE_TEXT.Length + 3), ResultButtonArea.Y + 1),
                Text = SAVE_TEXT,
                IsEnabled = false
            };
            btnCopy = new Button(COPY_TEXT.Length + 2)
            {
                Position = new Point(btnSave.Position.X - COPY_TEXT.Length - 3, btnSave.Position.Y),
                Text = COPY_TEXT,
                IsEnabled = false
            };
            btnClear = new Button(CLEAR_TEXT.Length + 2)
            {
                Position = new Point(btnCopy.Position.X - CLEAR_TEXT.Length - 3, btnCopy.Position.Y),
                Text = CLEAR_TEXT,
                IsEnabled = false
            };
            lblRepeat = new Label(REPEAT_TEXT)
            {
                Position = new Point(1, 2)
            };
            txtRepeat = new TextBox(pnlParameters.Width - 2)
            {
                Position = new Point(1, 3),
                Text = "1",
                IsNumeric = true,
                AllowDecimal = false,
                TextAlignment = HorizontalAlignment.Right,
                MaxLength = 2
            };
            lstResults = new ListBox(ResultArea.Width - 2, ResultArea.Height - 2)
            {
                Position = new Point(ResultArea.X + 1, ResultArea.Y + 1)
            };
            txtResults = new ScreenSurfaces.TextSurface(ResultArea.Width - 3, ResultArea.Height - 2, new CellSurface(ResultArea.Width - 4, ResultArea.Height - 4))
            {
                Position = new Point(ResultArea.X + 1, ResultArea.Y + 1),
                ScrollBarMode = SurfaceViewer.ScrollBarModes.AsNeeded
            };
            scrResults = new ScrollBar(Orientation.Vertical, 2)
            {
                Position = new Point(ResultArea.X + ResultArea.Width - 1, ResultArea.Y + 1)
            };
            
            pnlParameters.Add(lblParameters);
            pnlParameters.Add(lblRepeat);
            pnlParameters.Add(txtRepeat);

            btnClose.Click += btnClose_Click;
            btnGenerate.Click += btnGenerate_Click;
            btnClear.Click += btnClear_Click;
            btnCopy.Click += btnCopy_Click;
            btnSave.Click += btnSave_Click;

            ParseParameters();

            Controls.Add(btnClose);
            Controls.Add(lblName);
            Controls.Add(lblParameters);
            Controls.Add(pnlParameters);
            Controls.Add(btnGenerate);
            Controls.Add(btnClear);
            Controls.Add(btnCopy);
            Controls.Add(btnSave);
            Controls.Add(txtResults);
        }

        private void ParseParameters()
        {
            var labelWidth = pnlParameters.Width - 2;
            var controlWidth = pnlParameters.Width - 2;
            var y = 5;

            foreach (var parameter in _generator.Parameters)
            {
                Label label = new Label(labelWidth)
                {
                    DisplayText = $"{parameter.Key}:",
                    Position = new Point(1, y),
                    TextColor = Styles.LabelColor
                };
                y++; 
                ControlBase control = null;

                switch (parameter.Value.Type)
                {
                    case ParameterTypes.Text:
                        control = new TextBox(controlWidth)
                        {
                            Text = parameter.Value.Value
                        };
                        break;
                    case ParameterTypes.Integer:
                        control = new TextBox(controlWidth)
                        {
                            Text = parameter.Value.Value,
                            AllowDecimal = false,
                            IsNumeric = true
                        };
                        break;
                    case ParameterTypes.Decimal:
                        control = new TextBox(controlWidth)
                        {
                            Text = parameter.Value.Value,
                            AllowDecimal = true,
                            IsNumeric = true
                        };
                        break;
                    case ParameterTypes.List:
                        control = new ListBox(controlWidth, 4);
                        foreach (var option in parameter.Value.Options)
                            ((ListBox)control).Items.Add(option);
                        break;
                    case ParameterTypes.Date:
                        control = new TextBox(controlWidth)
                        {
                            Text = parameter.Value.Value
                        };
                        break;
                    case ParameterTypes.Boolean:
                        Boolean.TryParse(parameter.Value.Value, out Boolean value);
                        control = new CheckBox(controlWidth, 1)
                        {
                            IsSelected = value
                        };
                        break;
                }
                control.Position = new Point(1, y);
                control.Name = parameter.Key;
                _parameterControls.Add(control);
                pnlParameters.Add(label);
                pnlParameters.Add(control);
                y++;
            }
        }

        private Rectangle TitleBar { get; }
        private Rectangle ParameterArea { get; }
        private Rectangle ParameterButtonArea { get; }
        private Rectangle ResultButtonArea { get; }
        private Rectangle ResultArea { get; }
        private Rectangle ResultClientArea { get; }

        private Panel pnlButtons { get; }
        private Panel pnlParameters { get; }
        private Button btnClose { get; }
        private Button btnGenerate { get; }
        private Label lblName { get; }
        private Label lblParameters { get; }
        private Button btnClear { get; }
        private Button btnCopy { get; }
        private Button btnSave { get; }
        private Label lblRepeat { get; }
        private TextBox txtRepeat { get; }
        private ListBox lstResults { get; }
        private ScrollBar scrResults { get; }
        private ScreenSurfaces.TextSurface txtResults { get; }
    }
}
