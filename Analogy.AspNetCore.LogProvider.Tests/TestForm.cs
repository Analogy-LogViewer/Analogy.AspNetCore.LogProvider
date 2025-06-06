﻿using Analogy.Interfaces;
using Analogy.LogServer.Clients;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Analogy.LogServer.Tests
{
    public partial class TestForm : Form
    {
        private bool producing;
        private bool consuming;
        private ILogger<TestForm> Logger { get; set; }
        public TestForm()
        {
            InitializeComponent();
        }
        public TestForm(ILogger<TestForm> logger) : this()
        {
            Logger = logger;
        }

        private async void btnProducer_Click(object sender, EventArgs e)
        {
            if (producing)
            {
                return;
            }

            producing = true;
            btnProducer.Enabled = false;
            var p = new AnalogyMessageProducer($"http://{txtIP.Text}");
            var ai = new Dictionary<string, string> { { "some key", "some value" } };
            for (int i = 0; i < 100000; i++)
            {
                foreach (AnalogyLogLevel level in Enum.GetValues(typeof(AnalogyLogLevel)))
                {
                    await p.Log(text: "test " + i, source: "none", additionalInformation: ai, level: level).ConfigureAwait(false);
                }
                await Task.Delay(500).ConfigureAwait(false);
            }

            producing = false;
            btnProducer.Enabled = true;
        }

        private void btnConsumer_Click(object sender, EventArgs e)
        {
            //if (consuming) return;
            //consuming = true;
            //btnConsumer.Enabled = false;
            //var c = new AnalogyMessageConsumer("http://localhost:6000");
            //await foreach (var m in c.GetMessages().ConfigureAwait(false))
            //    richTextBox1.Text += Environment.NewLine + m;
            //consuming = false;
            //btnConsumer.Enabled = true;
        }

        private void btnProducerViaLogger_Click(object sender, EventArgs e)
        {
            Logger.LogInformation("test:" + DateTime.Now);
        }
    }
}