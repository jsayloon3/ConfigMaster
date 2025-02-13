using AutoMapper;
using BenchmarkDotNet.Exporters.Csv;
using ConfigMaster.BLL.Services;
using ConfigMaster.ControlConfigurations;
using ConfigMaster.DAL.DTO;
using CsvHelper;
using MaterialSkin.Controls;
using System.Globalization;

namespace ConfigMaster.Modals
{
    public partial class ConfigureReadOnlySettingsModal : Form
    {
        private string _title = string.Empty;
        private readonly IAuditTrailManagerService _auditTrailManagerService;
        private readonly IMapper _mapper;
        private List<AuditLogDTO> _auditLogViewModels = new();
        private List<AuditLogDTO> _auditLogViewModelClone = new();

        public ConfigureReadOnlySettingsModal(IAuditTrailManagerService auditTrailManagerService, IMapper mapper)
        {
            InitializeComponent();
            _auditTrailManagerService = auditTrailManagerService;
            _mapper = mapper;
        }

        public void Initialize(string title)
        {
            _title = title;
        }

        private void ExportAuditLogModal_Load(object sender, EventArgs e)
        {
            TitleLabel.Text = _title;
            LoadAuditLogs();
        }

        private int _currentPage = 1;
        private int TotalPages => (int)Math.Ceiling((double)_auditLogViewModels.Count / PageSize);
        private const int PageSize = 50;

        private async void LoadAuditLogs()
        {
            var auditLogs = await _auditTrailManagerService.GetAuditLogs();
            _auditLogViewModels = _mapper.Map<List<AuditLogDTO>>(auditLogs);
            DisplayPage(_currentPage);
            PaginationButtonVisibility();
        }

        private void PaginationButtonVisibility()
        {
            if ((_currentPage * PageSize) < _auditLogViewModels.Count)
            {
                NextButton.Enabled = true;

                if (_currentPage > 1)
                    PreviousButton.Enabled = true;
                else
                    PreviousButton.Enabled = false;
            }
            else
            {
                NextButton.Enabled = false;
                if (1 < _currentPage)
                    PreviousButton.Enabled = true;
                else
                { 
                    PreviousButton.Enabled = false;
                }
            }
        }

        private void DisplayPage(int pageNumber)
        {
            PaginationButtonVisibility();
            var paginatedLogs = _auditLogViewModels
                .Skip((pageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToList();
            AuditLogDataGridView.DataSource = paginatedLogs;
            PageLabel.Text = $"{pageNumber} of {TotalPages}";
        }

        private void NextPageButton_Click(object sender, EventArgs e)
        {
            if ((_currentPage * PageSize) < _auditLogViewModels.Count)
            {
                _currentPage++;
                DisplayPage(_currentPage);
            }
        }

        private void PreviousPageButton_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                DisplayPage(_currentPage);
            }
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            var auditLogViewModels = (List<AuditLogDTO>)AuditLogDataGridView.DataSource;

            ExportAuditLogs = new SaveFileDialog()
            {
                Filter = "CSV|*.csv",
                FileName = $"AuditLogs{DateTime.Now.ToString("yyyyMMdd")}.csv"
            };

            if (ExportAuditLogs.ShowDialog() == DialogResult.OK)
            {
                using (var writer = new StreamWriter(ExportAuditLogs.FileName))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(auditLogViewModels);
                }
                Close();
            }    
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AuditLogSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            var searchText = AuditLogSearchTextBox.Text.Trim().ToLower();
            var filteredLogs = _auditLogViewModels
                .Where(log => log.Action.ToLower().Contains(searchText) ||
                              log.Actor.ToLower().Contains(searchText) ||
                              log.Resource.ToLower().Contains(searchText) ||
                              log.Status.ToLower().Contains(searchText) ||
                              log.Created.ToString("yyyy-MM-dd").Contains(searchText))
                .ToList();
            AuditLogDataGridView.DataSource = filteredLogs;
        }
    }
}
